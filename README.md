# README

A small project demonstrating a use case for the [NRules](https://nrules.net) rules engine in C#.

- Demonstrates use of the Fluent DSL for rule definitions

- Forward chaining of rules via the IContext Update() method

```mermaid
flowchart TD
    Start["
    Is the car silent when
    you turn the key
    "]
    
    BTC["
    Are the
    battery
    terminals
    corroded"]

    Clean["
    Clean
    terminals
    and try
    starting
    again."]

    Replace["
    Replace
    cables
    and try
    again."]

    CarClick["
    Does the car
    make a
    clicking noise?"]

    RB["
    Replace the
    battery."]

    CF["
    Does the car
    crank up but
    fail to start?"]

    CheckSpark["
    Check spark
    plug
    connections."]

    ESD["
    Does the
    engine start
    and then die?"]

    FI["
    Does your
    car have fuel
    injection?"]
    
    CheckChoke["
    Check to
    ensure the
    choke is
    opening and
    closing."]
    
    Service["
    Get it in for
    service."]

    Start-- "Yes" -->BTC
    Start-- "No" -->CarClick

    BTC-- "Yes" -->Clean
    BTC-- "No" -->Replace
    
    CarClick-- "Yes" -->RB
    CarClick-- "No" -->CF
    
    CF-- "Yes" -->CheckSpark
    CF-- "No" -->ESD
    
    ESD-- "Yes" -->FI
    
    FI-- "Yes" -->Service
    FI-- "No" -->CheckChoke
```

## Dependencies

- DotNet SDK 8.0

## Running the project

> dotnet run

Answer prompts with 'y' or 'n' to see the rules in action.




