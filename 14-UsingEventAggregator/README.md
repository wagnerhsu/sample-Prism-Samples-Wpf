
## 2021-08-26
- Upgrade to `.NET 5.0`
- Add Serilog support
- Demo to send message in a separate thread and receive it in UI thread

## 2020-10-05
### Event Aggregator
- Define a event like `MessageSentEvent`
- In View Model, inject `IEventAggregator` and publish a event
- In other place, inject `IEventAggregator` and subscript the event