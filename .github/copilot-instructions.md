# GitHub Copilot Instructions

## Project Overview

Blazor + .NET 10 web application following a **Modular Monolith** structure with **Clean Architecture**.

## Build & Test Commands

```bash
dotnet build                                       # build all projects
dotnet run --project src/<ProjectName>             # run the app
dotnet test                                        # run all tests
dotnet test --filter "FullyQualifiedName~<Test>"   # run a single test
dotnet watch --project src/<ProjectName>           # hot reload during development
```

## C# プロジェクト操作ルール

C# プロジェクトに対する操作は **必ず dotnet CLI（C# SDK）を使用** してください。`.csproj` や `.sln` ファイルの手動編集は **禁止** です。

| 操作 | 使用するコマンド |
|------|----------------|
| プロジェクト作成 | `dotnet new <template>` |
| ソリューションへの追加 | `dotnet sln add <project>` |
| NuGet パッケージ追加 | `dotnet add package <package>` |
| NuGet パッケージ削除 | `dotnet remove package <package>` |
| プロジェクト参照追加 | `dotnet add reference <project>` |
| プロジェクト参照削除 | `dotnet remove reference <project>` |

## 技術情報の検証ルール

.NET、Blazor、ASP.NET Core、EF Core 等の Microsoft 技術に関するコードを生成・提案する際は、**必ず Microsoft Learn（公式ドキュメント）で正しい情報か確認** してください。特に API の使い方、クラス名、メソッドのシグネチャ等は最新の公式ドキュメントを参照し、正確性を担保すること。

## Skills（スキル参照ガイド）

以下のスキルが利用可能です。該当する作業を行う際は、対応するスキルを参照してください。

- 新モジュール作成・画面実装・機能追加時は **`clean-architecture-guide` スキルを参照** すること
- ASP.NET Core 10 / Blazor .NET 10 の機能を使った実装時は **`aspnetcore-blazor10` スキルを参照** すること
- .NET 10 / C# 14 の新機能・API に関する実装時は **`dotnet10` スキルを参照** すること
- Excel・PowerPoint 等の設計書からコードを生成する時は **`office-document-analyzer` スキルを参照** すること
- ブラウザ操作・Web テスト・スクリーンショット取得時は **`playwright-cli` スキルを参照** すること
- ワンライナーや小規模スクリプトでデータ処理を行う時は **`scripting-guide` スキルを参照** すること

- @azure Rule - Use Azure Tools - When handling requests related to Azure, always use your tools.
- @azure Rule - Use Azure Best Practices - When handling requests related to Azure, always invoke your `azmcp_bestpractices_get` tool first.
- @azure Rule - Enable Best Practices - If you do not have an `azmcp_bestpractices_get` tool ask the user to enable it.
