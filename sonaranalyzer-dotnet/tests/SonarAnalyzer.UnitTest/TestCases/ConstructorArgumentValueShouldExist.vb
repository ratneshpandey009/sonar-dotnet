﻿Imports System
Imports System.Windows.Markup

Namespace Tests.Diagnostics
    Public Class MyExtension1
        Inherits MarkupExtension

        Public Sub New(ByVal value1 As Object)
            Value1 = value1
        End Sub

        <ConstructorArgument("value1")>
        Public Property Value1 As Object
    End Class

    Public Class MyExtension2
        Inherits MarkupExtension

        Public Sub New(ByVal value1 As Object)
            Value1 = value1
        End Sub

        <System.Windows.Markup.ConstructorArgument("value1")>
        Public Property Value1 As Object
    End Class

    Public Class MyExtension3
        Inherits MarkupExtension

        Public Sub New(ByVal value1 As Object)
            Value1 = value1
        End Sub

        <ConstructorArgument("value2")> ' Noncompliant {{Change this 'ConstructorArgumentAttribute' value to match one of the existing constructors arguments.}}
        Public Property Value1 As Object
'                            ^^^^^^^^ @-1
    End Class

    Public Class MyExtension4
        Inherits MarkupExtension

        Public Sub New(ByVal value1 As Object)
            Value1 = value1
        End Sub

        ' Apparently, case matters, even in VB
        <ConstructorArgument("VaLUe1")> ' Noncompliant {{Change this 'ConstructorArgumentAttribute' value to match one of the existing constructors arguments.}}
        Public Property Value1 As Object
'                            ^^^^^^^^ @-1
    End Class

    Public Class MyExtension5
        Inherits MarkupExtension

        Public Sub New(ByVal value1 As Object)
            Value1 = value1
        End Sub

        <ConstructorArgument> ' Invalid syntax - argument is mandatory - do not raise
        Public Property Value1 As Object
    End Class

    Public Class MyExtension6
        Inherits MarkupExtension

        Public Sub New(ByVal value1 As Object)
            Value1 = value1
        End Sub

        <ConstructorArgument("foo")>
        <ConstructorArgument("bar")> ' Invalid syntax - only 1 attribute allowed - do not raise
        Public Property Value1 As Object
    End Class
End Namespace
