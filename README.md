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
| Week 1, Day 1 | Meeting Notes Summarizer | Turns raw, informal meeting notes into a structured markdown summary (Key Decisions / Action Items / Open Questions). Implemented for OpenAI and Claude using the **Strategy pattern**, letting the user pick a provider at runtime. | ✅ |
| Week 1, Day 2 | Meeting Notes Summarizer + Ollama provider | Same summarizer as Day 1, with **Ollama** added as a third interchangeable provider alongside OpenAI and Claude. | ✅ |

## Related

- Python version of the course exercises: [week1/community-contributions/rizwan_rumi](https://github.com/ed-donner/llm_engineering/tree/main/week1/community-contributions/rizwan_rumi) (PR-based contributions to the original course repo, organized per week)
- Original course repo: [ed-donner/llm_engineering](https://github.com/ed-donner/llm_engineering)

## License

For personal learning purposes.
