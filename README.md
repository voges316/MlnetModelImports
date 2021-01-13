# Import mlnet cli generated models using Microsoft.ML

Example shows importing and creating a prediction engine from a model generated
by mlnet cli tool. This works using v0.15.1 of mlnet cli tool, but appears to not
work with the more recent v16.2 mlnet cli tool.

```
# mlnet v0.15.1 command used to generate model
mlnet auto-train --task binary-classification --dataset data/yelp_labelled.txt --label-column-index 1 --has-header false --max-exploration-time 30 --name YelpDemo

# mlnet v16.2 command used to generate model
mlnet classification --dataset data/yelp_labelled.txt --has-header false --label-col 1 --train-time 30 --name YelpML16
```