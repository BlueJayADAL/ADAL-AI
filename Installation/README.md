
# Ubuntu 18.04.2 (Bionic Beaver) with CUDA

[![N|Solid](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBH8MYoq_M6I5yFqNsIH-SDUwR403f4nMKHONWwLjHR8InZN_1MA)](https://etown.edu)

After setting up Ubuntu 18.04, update the system.
```sh
$ sudo apt-get update
$ sudo apt-get upgrade
```
If 'Minimal installation' was selected, add essential components.
```sh
$ sudo apt-get install build-essential
```
Most of the directions have been taken from this [Medium] article with slight variations.
## Driver Installation
Now the correct driver has to be downloaded from [Driver]. Select the Graphics Card in your current system, `Linux 64-bit` as OS, and download the driver.

Navigate into the Downloads folder and make the `.run` file executable.
```sh
$ cd ~/Downloads
$ chmod +x NVIDIA-Linux-x86_64-[driver_version].run
```
Now the driver installer can be run.
```sh
$ sudo ./NVIDIA-Linux-x86_64-[driver_version].run
```
If the installer prompts any warning about version, just continue with `OK`.
After the install is finished restart the computer.
```sh
$ sudo reboot
```
Verify the driver installation this should show the driver version which is in the file name from the installer
```sh
$ nvidia-smi
```
## CUDA installation
Open the [CUDA] driver download page and select the correct version. For the installer type select `runfile (local)`.
Navigate once more into the `Downloads` folder and make the `.run` file executeable.
```sh
$ cd ~/Downloads
$ sudo chmod +x cuda_[cuda-version]_linux.run
```
Use <kbd>Ctrl</kbd>+<kbd>Alt</kbd>+<kbd>F4</kbd> to change to a tty without a GUI and unload the kernel.
```sh
$ sudo systemctl isolate multi-user.target
$ sudo modprobe -r nvidia-drm
```
Now run the installer.
```sh
$  sudo ./cuda_[cuda-version][cuda-subversion]_linux.run
```
:information_source: The cuda version is usully in the `x.y` format. (Example: 10.1)
Type **accept** when asked to agree with the terms of service.
After the installation is finished, export the PATH to the CUDA installation and check if the installation was successful.
```sh
$ export PATH=/usr/local/cuda-[cuda_version]/bin${PATH:+:${PATH}}
$ nvcc -V
```
Now that CUDA is installed, switch back to the GUI with <kbd>Ctrl</kbd>+<kbd>Alt</kbd>+<kbd>F1</kbd>.
In order for the paths to work permanently, they should be added to the `.profile` file or `.bashrc`
```sh
$ sudo nano ~/.profile
```
or
```sh
$ sudo nano ~/.bashrc
```

Add to the end of the file.
```
export PATH=/usr/local/cuda-[cuda_version]/bin${PATH:+:${PATH}}
export LD_LIBRARY_PATH=/usr/local/cuda-[cuda_version]/lib64${LD_LIBRARY_PATH:+:${LD_LIBRARY_PATH}}
```
Verify the installation and successful exports.
```sh
$ source ~/.bashrc
$ nvcc -V
```

## cuDNN Installation
Follow Step 3 of this [cuDNN] post. 

Locate and Download NVIDIA’s cuDNN 7.4

## Tensorflow Benchmark
The benchmark requires Python3.
First make sure that **virtualenv** is installed.
If not install via the `apt` package manager.
```sh
$ sudo apt-get install python3-venv 
```
Now clone the benchmark tests from the [Tensorflow] Github, change into the folder, create a virtualenv `venv`, and activate it.
```sh
$ git clone  https://github.com/tensorflow/benchmarks.git
$ cd benchmarks
$ virtualenv -p python3 venv
$ source venv/bin/activate
```
Now install Tensorflow for GPUs.
```sh
$ pip install tensorflow-gpu
```
Now run the benchmark script with however many GPUs you are trying to test. (In this example two GPUs are used)
```sh
$ python scripts/tf_cnn_benchmarks/tf_cnn_benchmarks.py --num_gpus=2
```
A reference for the benchmark performance can be found [here](https://www.tensorflow.org/guide/performance/benchmarks).

## Installation with Anaconda Tensorflow
If having an `Illegal instruction (core dumped)` error when executing `import tensorflow as tf`, it means the host computer CPU is too old and does not support AVX instruciton set. There are two options to get around this: 1) build from source (may be buggy); or 2) use Anaconda tensorflow, which is not pre-compiled with AVX option. 

Follow this [Conda] post to setup. 

[Driver]: <https://www.nvidia.com/Download/index.aspx?lang=en-us>
[CUDA]: <https://developer.nvidia.com/cuda-downloads?target_os=Linux&target_arch=x86_64&target_distro=Ubuntu&target_version=1804&target_type=runfilelocal>
[Medium]: <https://medium.com/@avinchintha/how-to-install-nvidia-drivers-and-cuda-10-0-for-rtx-2080-ti-gpu-on-ubuntu-16-04-18-04-ce32e4edf1c0>
[Tensorflow]: <https://github.com/tensorflow/benchmarks>
[cuDNN]: <https://medium.com/@cjanze/how-to-install-tensorflow-with-gpu-support-on-ubuntu-18-04-lts-with-cuda-10-nvidia-gpu-312a693744b5>
[Conda]: <https://medium.com/datadriveninvestor/install-tensorflow-gpu-to-use-nvidia-gpu-on-ubuntu-18-04-do-ai-71b0ce64ebc5>

