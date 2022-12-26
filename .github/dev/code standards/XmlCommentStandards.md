# General

* When possible, link to the [Glossary](/man/manGlossary.html)

# Classes

## Summary

```csharp
/// <summary>
/// A short summary of what the class does/is responsible for.
/// </summary>
```

## Remarks

* Can contain a `<list>`
* Can contain an `<example>`

### Simple

```csharp
/// <remarks>
/// Remarks provide additional details.
/// </remarks>
```

### Simple

```csharp
/// <remarks>
/// <para>
/// Longer remark sections...
/// </para>
/// <para>
/// ...should be seperated by paragraphs
/// </para>
/// </remarks>
```

## Lists

* Contained in `<remarks>` section
* Items can have links:  
`<item>An item with a <see href="url">link</see> that goes somewhere.</item>`

### Bullet

* Each `<item></item>` is on one line.

```csharp
/// Here is a list
/// <list type="bullet">
/// <item>The first item</item>
/// <item>An item with a <see href="url">link</see> that goes somewhere.</item>
/// </list>
```

### Number

* Each `<item></item>` is on one line.

```csharp
/// Here is a list
/// <list type="number">
/// <item>The first item</item>
/// <item>An item with a <see href="url">link</see> that goes somewhere.</item>
/// </list>
```

### Table

* Tables must have a `<listheader>`, contained on multiple lines
* Items are on multiple lines
* Item `<term></term>` and `<description></description>` are on seperate lines
* Default values are ***bold and italic*** (using `<b><i>tags</i></b>`)

```csharp
/// <list type="table">
/// <listheader>
/// <term>Setting</term>
/// <description>Description</description>
/// </listheader>
/// <item>
/// <term><b><i>enabled</i></b></term>
/// <description>All Abatab functionality is (potentially) available.</description>
/// </item>
/// <item>
/// <term>disabled</term>
/// <description>Abatab functionality is not available.</description>
/// </item>
/// <item>
/// <term>passthrough</term>
/// <description>All functionality is available, but no changes are made to Avatar.</description>
/// </item>
/// </list>
```

## Links

```csharp
/// <seealso href="link">Link Text</seealso>
```

## Examples


Class with example

```csharp
/// <summary>
///   <para>
///     Roundhouse classes determine what should be done with the Script Parameter sent from Avatar. This
///     particular Roundhouse class determines what should be done with the Module component.
///   </para>
///   <para>
///     For example, <c>QuickMedOrder-Dose-VerifyAmount</c> would be sent to the Roundhouse class of the
///     ModQuickMedOrder module, where it would be processed further.
///   </para>
/// </summary>
```





## Tables

Standard table

```csharp
/// <list type="table">
/// <listheader>
/// <term>Setting</term>
/// <description>Description</description>
/// </listheader>
/// <item>
/// <term><b><i>enabled</i></b></term>
/// <description>All Abatab functionality is (potentially) available.</description>
/// </item>
/// <item>
/// <term>disabled</term>
/// <description>Abatab functionality is not available.</description>
/// </item>
/// <item>
/// <term>passthrough</term>
/// <description>All functionality is available, but no changes are made to Avatar.</description>
/// </item>
/// </list>
```

## Bullet lists

Standard bullet list

```csharp
    /// <list type="bullet">
    /// <item><term>Standard session properties</term></item>
    /// <item><term>Debugging functionality</term></item>
    /// <item><term>Logging functionality</term></item>
    /// </list>
```


[Logo]: /.github/res/img/logo/RepositoryLogo.png
