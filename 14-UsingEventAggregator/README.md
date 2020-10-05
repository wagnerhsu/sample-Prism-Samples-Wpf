## 2020-10-05
### Event Aggregator
- Define a event like `MessageSentEvent`
- In View Model, inject `IEventAggregator` and publish a event
- In other place, inject `IEventAggregator` and subscript the event