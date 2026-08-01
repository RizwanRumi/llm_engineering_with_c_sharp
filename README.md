# LLM Engineering with C#

A C# / .NET companion project to [Ed Donner's LLM Engineering course](https://github.com/ed-donner/llm_engineering) (originally taught in Python).

The goal of this repo is to re-implement each exercise from the course in C#, comparing multiple LLM providers side by side — starting with **OpenAI** and **Anthropic (Claude)** — while practicing clean, extensible design patterns along the way.

## Why this exists

The original course is built around Python and the OpenAI API. This repo exists to:
- Practice applying the same LLM engineering concepts in C# / .NET
- Compare OpenAI and Anthropic (and potentially other providers) using a consistent, swappable interface
- Reinforce good software design (e.g. the Strategy pattern) while working with real LLM APIs

## Tech stack

- **.NET 8+**
- [`OpenAI`](https://www.nuget.org/packages/OpenAI) — official OpenAI .NET SDK
- [`Anthropic`](https://www.nuget.org/packages/Anthropic) — official Anthropic .NET SDK (currently in beta)
- [Ollama](https://ollama.com) — runs local open-weight models (e.g. `llama3.2`) behind Ollama's OpenAI-compatible endpoint, reusing the `OpenAI` SDK with a `localhost` base URL
- Environment variables (`OPENAI_API_KEY`, `ANTHROPIC_API_KEY`) for API key management; Ollama needs no real key since it runs locally

## Getting started

### Prerequisites
- Visual Studio 2022 (or any .NET 8+ compatible IDE)
- An OpenAI API key ([platform.openai.com](https://platform.openai.com))
- An Anthropic API key ([console.anthropic.com](https://console.anthropic.com))
- [Ollama](https://ollama.com) installed locally with a model pulled, e.g.:
  ```bash
  ollama pull llama3.2
  ```

### Setup

1. Clone the repo:
   ```bash
   git clone https://github.com/RizwanRumi/llm_engineering_with_c_sharp.git
   ```

2. Set your API keys as environment variables (PowerShell):
   ```powershell
   setx OPENAI_API_KEY "your_openai_key_here"
   setx ANTHROPIC_API_KEY "your_anthropic_key_here"
   ```
   > Restart Visual Studio after running `setx` — environment variables set this way only apply to new processes.
   >
   > Ollama doesn't check the API key, so no `ANTHROPIC`/`OPENAI`-style setup is needed for it — just have `ollama serve` running with a model pulled.

3. Open the solution in Visual Studio 2022 and restore NuGet packages.

4. Run the console app (`Ctrl+F5`).

## Exercises

| Week | Exercise | Description | Status |
|---|---|---|---|
| Week 1, Day 1 | Email Subject Line Generator | Given an email body, suggests a short, professional subject line. Implemented for OpenAI and Claude using the **Strategy pattern**, letting the user pick a provider at runtime. | ✅ |
| Week 1, Day 2 | Meeting Notes Summarizer + Ollama provider | Reuses the Day 1 classes/interfaces (renamed to the generic `TextGen*`/`*TextGenerationStrategy`) to turn raw, informal meeting notes into a structured markdown summary (Key Decisions / Action Items / Open Questions), and adds **Ollama** as a third interchangeable provider alongside OpenAI and Claude. `Program.cs` currently runs this version. | ✅ |

## Project structure

```
LLMConsoleApp/
└── Week1/
    └── Day1/
        ├── TextGenOpenAI.cs            # single-provider reference version (OpenAI)
        ├── TextGenClaude.cs            # single-provider reference version (Claude)
        ├── TextGenOllama.cs            # single-provider reference version (Ollama)
        └── StrategyPattern/
            ├── ITextGenerationStrategy.cs
            ├── OpenAiTextGenerationStrategy.cs
            ├── ClaudeTextGenerationStrategy.cs
            ├── OllamaTextGenerationStrategy.cs
            └── TextGenerator.cs
Program.cs
```

## Design notes

- **Strategy pattern** is used to abstract away provider-specific API differences (OpenAI's `ChatClient`, Anthropic's `AnthropicClient`, and Ollama via its OpenAI-compatible endpoint) behind a common interface, so calling code stays provider-agnostic and new providers can be added without touching existing code.
- Each exercise typically has:
  - An interface (e.g. `ITextGenerationStrategy`)
  - One concrete strategy class per provider (e.g. `OpenAiTextGenerationStrategy`, `ClaudeTextGenerationStrategy`, `OllamaTextGenerationStrategy`)
  - A small context class that wraps the chosen strategy
- **Ollama** is added as a provider by pointing the `OpenAI` SDK's `ChatClient` at Ollama's local, OpenAI-compatible endpoint (`http://localhost:11434/v1`) instead of OpenAI's own API — no separate SDK is needed, and the API key is a non-empty placeholder since Ollama doesn't validate it.
- `TextGenOpenAI.cs`, `TextGenClaude.cs`, and `TextGenOllama.cs` (in `Week1/Day1/`) are the original, single-provider versions written before the Strategy pattern refactor. They're kept intentionally as a **before/after reference** — showing the direct, hardcoded provider call versus the abstracted, swappable version in `StrategyPattern/`. `Program.cs` has the calls to these earlier versions commented out, with the Strategy pattern version active by default.
- The Day 2 (meeting notes) exercise reuses the Day 1 classes/interfaces rather than duplicating them into a `Week1/Day2/` folder. They were originally named around "subject line" (from the Day 1 exercise) but have been renamed to the generic `TextGen*`/`*TextGenerationStrategy` naming above, since the same provider-abstraction code now backs a different kind of output (a structured summary instead of a one-line subject).

## Related

- Python version of the course exercises: [week1/community-contributions/rizwan_rumi](https://github.com/ed-donner/llm_engineering/tree/main/week1/community-contributions/rizwan_rumi) (PR-based contributions to the original course repo, organized per week)
- Original course repo: [ed-donner/llm_engineering](https://github.com/ed-donner/llm_engineering)

## License

For personal learning purposes.
