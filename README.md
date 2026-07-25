# \# LLM Engineering with C#

# 

# A C# / .NET companion project to \[Ed Donner's LLM Engineering course](https://github.com/ed-donner/llm\_engineering) (originally taught in Python).

# 

# The goal of this repo is to re-implement each exercise from the course in C#, comparing multiple LLM providers side by side — starting with \*\*OpenAI\*\* and \*\*Anthropic (Claude)\*\* — while practicing clean, extensible design patterns along the way.

# 

# \## Why this exists

# 

# The original course is built around Python and the OpenAI API. This repo exists to:

# \- Practice applying the same LLM engineering concepts in C# / .NET

# \- Compare OpenAI and Anthropic (and potentially other providers) using a consistent, swappable interface

# \- Reinforce good software design (e.g. the Strategy pattern) while working with real LLM APIs

# 

# \## Tech stack

# 

# \- \*\*.NET 8+\*\*

# \- \[`OpenAI`](https://www.nuget.org/packages/OpenAI) — official OpenAI .NET SDK

# \- \[`Anthropic`](https://www.nuget.org/packages/Anthropic) — official Anthropic .NET SDK (currently in beta)

# \- Environment variables (`OPENAI\_API\_KEY`, `ANTHROPIC\_API\_KEY`) for API key management

# 

# \## Getting started

# 

# \### Prerequisites

# \- Visual Studio 2022 (or any .NET 8+ compatible IDE)

# \- An OpenAI API key (\[platform.openai.com](https://platform.openai.com))

# \- An Anthropic API key (\[console.anthropic.com](https://console.anthropic.com))

# 

# \### Setup

# 

# 1\. Clone the repo:

# &#x20;  ```bash

# &#x20;  git clone https://github.com/RizwanRumi/llm\_engineering\_with\_c\_sharp.git

# &#x20;  ```

# 

# 2\. Set your API keys as environment variables (PowerShell):

# &#x20;  ```powershell

# &#x20;  setx OPENAI\_API\_KEY "your\_openai\_key\_here"

# &#x20;  setx ANTHROPIC\_API\_KEY "your\_anthropic\_key\_here"

# &#x20;  ```

# &#x20;  > Restart Visual Studio after running `setx` — environment variables set this way only apply to new processes.

# 

# 3\. Open the solution in Visual Studio 2022 and restore NuGet packages.

# 

# 4\. Run the console app (`Ctrl+F5`).

# 

# \## Exercises

# 

# | Week | Exercise | Description | Status |

# |---|---|---|---|

# | Week 1 | Email Subject Line Generator | Given an email body, suggests a short, professional subject line. Implemented for both OpenAI and Claude using the \*\*Strategy pattern\*\*, letting the user pick a provider at runtime. | ✅ |

# 

# \## Project structure

# 

# ```

# LLMConsoleApp/

# └── Week1/

# &#x20;   └── Day1/

# &#x20;       ├── SubjectGenOpenAI.cs         # earlier, single-provider reference version

# &#x20;       ├── SubjectGenClaude.cs         # earlier, single-provider reference version

# &#x20;       └── StrategyPattern/

# &#x20;           ├── ISubjectLineStrategy.cs

# &#x20;           ├── OpenAiSubjectLineStrategy.cs

# &#x20;           ├── ClaudeSubjectLineStrategy.cs

# &#x20;           └── SubjectLineGenerator.cs

# Program.cs

# ```

# 

# \## Design notes

# 

# \- \*\*Strategy pattern\*\* is used to abstract away provider-specific API differences (OpenAI's `ChatClient` vs. Anthropic's `AnthropicClient`) behind a common interface, so calling code stays provider-agnostic and new providers can be added without touching existing code.

# \- Each exercise typically has:

# &#x20; - An interface (e.g. `ISubjectLineStrategy`)

# &#x20; - One concrete strategy class per provider (e.g. `OpenAiSubjectLineStrategy`, `ClaudeSubjectLineStrategy`)

# &#x20; - A small context class that wraps the chosen strategy

# \- `SubjectGenOpenAI.cs` and `SubjectGenClaude.cs` (in `Week1/Day1/`) are the original, single-provider versions written before the Strategy pattern refactor. They're kept intentionally as a \*\*before/after reference\*\* — showing the direct, hardcoded provider call versus the abstracted, swappable version in `StrategyPattern/`. `Program.cs` has the calls to these earlier versions commented out, with the Strategy pattern version active by default.

# 

# \## Related

# 

# \- Python version of the course exercises: \[community-contributions/rizwan\_rumi](https://github.com/ed-donner/llm\_engineering/tree/main/community-contributions) (PR-based contributions to the original course repo)

# \- Original course repo: \[ed-donner/llm\_engineering](https://github.com/ed-donner/llm\_engineering)

# 

# \## License

# 

# For personal learning purposes.



