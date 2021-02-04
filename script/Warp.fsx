#r "nuget: CliWrap"

open CliWrap

let x =
    Cli.Wrap("set").WithArguments("x 100")
        .ExecuteAsync().GetAwaiter().GetResult()