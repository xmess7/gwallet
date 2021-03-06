﻿namespace GWallet.Backend

open System

type ExceptionInfo =
    { TypeFullName: string
      Message: string }

type HistoryInfo =
    { TimeSpan: TimeSpan
      Fault: Option<ExceptionInfo> }

[<CustomEquality; NoComparison>]
type Server<'K,'R when 'K: equality> =
    { Identifier: 'K
      HistoryInfo: Option<HistoryInfo>
      Retrieval: Async<'R> }
    override self.Equals yObj =
        match yObj with
        | :? Server<'K,'R> as y ->
            self.Identifier.Equals y.Identifier
        | _ -> false
    override self.GetHashCode () =
        self.Identifier.GetHashCode()
