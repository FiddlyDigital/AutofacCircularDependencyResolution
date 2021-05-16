# Resolve Autofac Circular Dependencies (without massive refactoring)

This project is a working example of how to overcome circular dependenices using Autofac DI.

I came across this issue recently during massive refactoring effort on a large codebase. I didn't have the time to go ahead and correctly split and refactor all classes, so did some searching and found a great solution proposed by Thomas Levesque.

The solution is that instead of rewriting all of your logic, you can Lazily resolve dependencies when used - not when they're injected into the constructor.
Its more of a band-aid rather than a long-term fix, but it can get you out of trouble during an interim refactoring step.

## Steps

1. Implement the _ServiceCollectionExtensions_ in your project _(Extensions\ServiceCollectionExtensions.cs)_
2. Add LazyResolution to your ServiceProvider _(See Program.cs)_
3. Wrap required Interfaces with _Lazy<>_ both:
   1. When defined: ```private readonly Lazy<IItemTestManager> _itemTestManager;```
   2. When injected: ```public ItemManager(Lazy<IItemTestManager> itemTestManager)```
   3. See _ItemManager_ and _ItemTestManager_ for example usage
4. Use ```<T>.Value.``` to call methods on the LazilyInjected item
   1. e.g. ```_itemTestManager.Value.Test(items);```

## Notes

* Don't access the _Lazy<>_ injected classes in the Constructor of the Injectee!
