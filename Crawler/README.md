# Crawler demonstration
[![N|Solid](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBH8MYoq_M6I5yFqNsIH-SDUwR403f4nMKHONWwLjHR8InZN_1MA)](https://etown.edu)
## Installation
:information_source: The Guide currently is for a Windows 10 demonstration

:information_source: [ML-Agents](https://github.com/Unity-Technologies/ml-agents) requires Python 3.6 (64-bit)

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
mlagents-learn config\crawler_config.yaml --env=envs\TrainingCrawler\Crawler.exe --run-id=[run-id]
```
|Command|Description  |
|--|--|
|`--train`|Trains the model|
|`--slow`|Visual output is at much higher frame rate and resolution (Slows down training significantly)|
|`--no-graphics`|Does not display any graphics(Speeds up training)|
|`--load`|If a model with the same id exists it will continue to train it (If `max_steps` in the config file are reached, no training will happen. This can be used to visually check how well the model is performing. (Make sure to use `--slow` to have a fluent visual)|

A normal training process would look the following way:
```console
mlagents-learn config\crawler_config.yaml --env=envs\TrainingCrawler\Crawler --run-id=[run-id] --train
```
### Use trained model
In order to use a trained model enter the following command:
```console
mlagents-learn config\crawler_config.yaml --env=envs\TrainingCrawler\Crawler.exe --run-id=[name_of_trained_model] --slow --load
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

The standalone executable in `envs\DemoCrawler` has 3 models available:

|  |max_steps|hidden_units|num_layers|Training time|
|--|--|--|--|--|
|Bad Model|100,000|512|3|18 Minutes|
|Fair Model|1,000,000|512|5|TBD|
|Good Model|2,500,000|512|7|TBD|
