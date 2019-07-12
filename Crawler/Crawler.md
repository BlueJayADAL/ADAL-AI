# Crawler demonstration
[![N|Solid](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBH8MYoq_M6I5yFqNsIH-SDUwR403f4nMKHONWwLjHR8InZN_1MA)](https://etown.edu)
## Installation
:information_source: The Guide currently is for a Windows 10 demonstration
:information_source: [ML-Agents](https://github.com/Unity-Technologies/ml-agents) requires Python 3.6 

1. Clone the repository or download directly from GitHub (If  downloaded extract the files)
2. Open the Command Prompt
3. Navigate into the root folder
4. Create a Python virtual environmental, and activate it: 
```console
python -m venv venv 
venv\Scripts\activate
 ```
 5. Install requirements
```console
pip install -r requirements.txt
 ```
## Usage
### Start training a model
1. Change the parameters in `config\crawler.config`
2. Enter command into Command Prompt, replace `run-id` with a model name of your choice.
```console
mlagents-learn config\crawler_config.yaml --env=envs\Crawler\Crawler.exe --run-id=[run-id]
```
|Command|Description  |
|--|--|
|`--train`|Trains the model|
|`--slow`|Visual output is at much higher frame rate and resolution (Slows down training significantly)|
|`--no-graphics`|Does not display any graphics(Speeds up training)|
|`--load`|If a model with the same id exists it will continue to train it (If `max_steps` in the config file are reached, nothing will happen|
A normal training process would look the following way:
```console
mlagents-learn config\crawler_config.yaml --env=envs\Crawler\Crawler --run-id=[run-id] --train
```
### Use trained model
In order for using the already supplied trained model enter the following command:
```console
mlagents-learn config\crawler_config.yaml --env=envs\Crawler\Crawler.exe --run-id=DynamicCrawler-1DS-7L --slow --load
```


## Tensorboard
:information_source: [Tensorboard](https://github.com/tensorflow/tensorboard) requires a second Command Prompt.
1. Make sure to have the environment activated
2.  Start Tensorboard
```console
tensorboard --logdir=summaries --host=localhost
```
3. Open Tensorboard at [localhost:6006](http://localhost:6006)

## Demonstration
### Untrained model just starting to learn
```console
mlagents-learn config\crawler_config.yaml --env=envs\Crawler\Crawler.exe --run-id=demo-run --slow
```
### 30 hours of 
```console
mlagents-learn config\crawler_config.yaml --env=envs\Crawler\Crawler.exe --run-id=DynamicCrawler-1DS-7L --slow --load
```

