# Async in C# Deep Dive

This is not yet another session on how to use async/await. You are probably already using that so we won't bore each other with the syntax. Instead we shall be diving deep into how Async actually works and having a look at the benefits and pitfalls.

The way Async is being described, it sounds like it will make your code faster and more scalable, whilst solving all your problems and achieving world peace - all before lunch.  

Async certainly can help you do more I/O in parallel and may in some circumstances help you scale. But did you know Async code can sometimes also use more memory, make your code slower and can introduce subtle bugs that may only appear in production?   

Understanding how Async in C# works under the covers is crucial to be able to harness the benefits it can give you, whilst avoiding the pitfalls. This session aims to give you that understanding.

