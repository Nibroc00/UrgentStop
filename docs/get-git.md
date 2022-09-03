# Getting set up with git for the urgent stop project

## Installing Git-lfs

- Git lfs uses a separate server for easier managing of large files. 
  - Visit [https://git-lfs.github.io/](https://git-lfs.github.io/) for an installation guide.
  - On Linux, you likely just need to install the `git-lfs` package from your distro's repository.
  - You know this is installed if `git lfs version` doesn't give an error.
- Once the extension in step is installed, run `git lfs install`.
  - This only needs to be done once per user.

## Cloning and Configuring the Urgent Stop repo

- Note that to interact with the remote repository you will need to be on the USU network or using a VPN.
  - [VPN instructions](https://usu.service-now.com/aggies?id=kb_article_view&sysparm_article=KB0011477&sys_kb_id=fb3eb5d2b8834100bd5c10e091b7dbf3&spa=1)
- Clone the repo using `git clone mater@129.123.24.8:urgentstop.git`.
  - That should be it! The remote `origin` should already be set and you are good to go.

Now all you need to do is follow step 2 of [this unity guide](https://thoughtbot.com/blog/how-to-git-with-unity#2-configure-unity-for-version-control) to help ensure that everything works as expected and Unity doesn't do anything weird.

-----

# Some Notes & References

I think that it may be useful to document what I did to set up git-lfs on the server, for when something breaks. No further action needs to be taken.

## (re)starting the server
The following are the steps to get the server going:

1. If the server is running, kill the currently running server
2. `cd giftless`
3. `source .venv/bin/activate`
4. `export FLASK_APP=giftless.wsgi_entrypoint`
5. `export GIFTLESS_CONFIG_FILE=giftless.conf.yaml`
6. `flask run -h 129.123.24.8`

This is in a shell script on mater:
- `./giftless/restart.sh`

## Setting up lfs 

This is the original setup for later reference.

It looks as if git-lfs runs as an HTTP server. There are [multiple implementations](https://github.com/git-lfs/git-lfs/wiki/Implementations) out there, but I will use [https://github.com/datopian/giftless](this implementation) because the documentation is nice, it is maintained, and it is written in python. To set this up I created a `giftless` directory on mater and did the following:

- `sudo apt install python3.8-venv`
- `python3 -m venv .venv`
- `source .venv/bin/activate`
- `pip install uwsgi`
- `pip install giftless`
- ` pip install -Ur https://raw.githubusercontent.com/datopian/giftless/master/requirements.txt`
- `export FLASK_APP=giftless.wsgi_entrypoint`
- `flask run`
  - this successfully runs the server
  
This was following along with the [getting started guide](https://giftless.datopian.com/en/latest/quickstart.html). Now we will configure giftless by creating a config file in `giftless.conf.yaml`:

```
AUTH_PROVIDERS:
       - giftless.auth.allow_anon:read_write
```

Note this does remove authentication; but hopefully that's ok for now. 

Now we will run giftless with this config
- `export GIFTLESS_CONFIG_FILE=giftless.conf.yaml`
- `flask run -h 129.123.24.8`
  - the `-h` flag makes it not run on localhost
  
## Concerns

The server running is a development server, not a production server. I am inexperienced and have no idea if that is problem.

### A weird bug
At first, I kept getting a bug when pulling from the server. Apparently giftless changes the names of the files to make them HTTP compliant, but it was trying to change files of type `None`.

```
File "/home/mater/giftless/.venv/lib/python3.8/site-packages/flask_classful.py", line 269, in inner
    return fn(*args, **kwargs)
  File "/home/mater/giftless/.venv/lib/python3.8/site-packages/giftless/transfer/basic_streaming.py", line 85, in get
    filename = safe_filename(filename)
  File "/home/mater/giftless/.venv/lib/python3.8/site-packages/giftless/util.py", line 84, in safe_filename
    return ''.join(c for c in original_filename if c in valid_chars)
TypeError: 'NoneType' object is not iterable
```

As a hacky workaround, I commented out line 85 of `/giftless/.venv/lib/python3.8/site-packages/giftless/transfer/basic_streaming.py` which called the function to ensure that filenames comply with http. Everything seems to be working now, but obviously this is a terrible solution.

### Update 16/03/22
I have now implemented what I think is a more robust solution to the problem. In the aforementioned commented out line of code I now check if the type of the file name is `None` before calling the function. As far as I can tell everything seems to be working, even with rediculous file names.

## Setting Up the Git remote

First, we need to install git lfs.
- `sudo apt install git-lfs`

Now we need to create the repo:
- `mkdir urgentstop.git && cd urgentstop.git`
- `git init --bare`

Everything is set up on mater. Now we need to create and configure the repo.

## Configuring the repo

### Making LFS behave
To make git look in the right place for the lfs server I ran the following command (in the local repo):
- `git config -f .lfsconfig lfs.url http://129.123.24.8:5000/usu/urgentstop`

Now when cloning/pushing/pulling git should know where to look.

### Unity Specific
To get git to work well for this project, I will refer to this [blog post](https://thoughtbot.com/blog/how-to-git-with-unity). This covers getting the `.gitignore` files and `.gitattributes` files set up how we want.

For now, copying [github's unity gitignore](https://github.com/github/gitignore/blob/main/Unity.gitignore) should be good enough.

The gitattributes file will be taken directly from that blog post, because I don't know any better:

```
# 3D models
*.3dm filter=lfs diff=lfs merge=lfs -text
*.3ds filter=lfs diff=lfs merge=lfs -text
*.blend filter=lfs diff=lfs merge=lfs -text
*.c4d filter=lfs diff=lfs merge=lfs -text
*.collada filter=lfs diff=lfs merge=lfs -text
*.dae filter=lfs diff=lfs merge=lfs -text
*.dxf filter=lfs diff=lfs merge=lfs -text
*.fbx filter=lfs diff=lfs merge=lfs -text
*.jas filter=lfs diff=lfs merge=lfs -text
*.lws filter=lfs diff=lfs merge=lfs -text
*.lxo filter=lfs diff=lfs merge=lfs -text
*.ma filter=lfs diff=lfs merge=lfs -text
*.max filter=lfs diff=lfs merge=lfs -text
*.mb filter=lfs diff=lfs merge=lfs -text
*.obj filter=lfs diff=lfs merge=lfs -text
*.ply filter=lfs diff=lfs merge=lfs -text
*.skp filter=lfs diff=lfs merge=lfs -text
*.stl filter=lfs diff=lfs merge=lfs -text
*.ztl filter=lfs diff=lfs merge=lfs -text
# Audio
*.aif filter=lfs diff=lfs merge=lfs -text
*.aiff filter=lfs diff=lfs merge=lfs -text
*.it filter=lfs diff=lfs merge=lfs -text
*.mod filter=lfs diff=lfs merge=lfs -text
*.mp3 filter=lfs diff=lfs merge=lfs -text
*.ogg filter=lfs diff=lfs merge=lfs -text
*.s3m filter=lfs diff=lfs merge=lfs -text
*.wav filter=lfs diff=lfs merge=lfs -text
*.xm filter=lfs diff=lfs merge=lfs -text
# Fonts
*.otf filter=lfs diff=lfs merge=lfs -text
*.ttf filter=lfs diff=lfs merge=lfs -text
# Images
*.bmp filter=lfs diff=lfs merge=lfs -text
*.exr filter=lfs diff=lfs merge=lfs -text
*.gif filter=lfs diff=lfs merge=lfs -text
*.hdr filter=lfs diff=lfs merge=lfs -text
*.iff filter=lfs diff=lfs merge=lfs -text
*.jpeg filter=lfs diff=lfs merge=lfs -text
*.jpg filter=lfs diff=lfs merge=lfs -text
*.pict filter=lfs diff=lfs merge=lfs -text
*.png filter=lfs diff=lfs merge=lfs -text
*.psd filter=lfs diff=lfs merge=lfs -text
*.tga filter=lfs diff=lfs merge=lfs -text
*.tif filter=lfs diff=lfs merge=lfs -text
*.tiff filter=lfs diff=lfs merge=lfs -text
```
