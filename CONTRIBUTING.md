# Style Guide
This is the style guide to be used as standard by our programmers.

## Prologues
Prologues must be provided for any publicly visible interface (class, primitive type, data member, etc.) It is also suggested to provide class and method prologues, even if `private`.

### Class
		/// <summary>
		/// (DESCRIPTION)
		/// </summary>
        /// <author>
        /// (AUTHOR)
        /// </author

### Method
 		/// <summary>
        /// (DESCRIPTION)
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// (CONTRIBUTORS)
        /// </remarks>
        /// <param name="(PARAM NAME)">(DESCRIPTION)</param>
        /// <param name="(PARAM NAME 2)">(DESCRIPTION)</param>
        /// ...
        
### Property
		/// <summary>
        /// (DESCTRIPTION)
        /// </summary>
        
### Variable
		/// <summary>
        /// (DESCTRIPTION)
        /// </summary>
        
## Comments
It is recommended to use the comment style guide as [suggested by Microsoft](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions).
* Place the comment on a separate line, not at the end of a line of code.
* Use standard case (begin with upper case).
* End comment text with a period.
* Insert one space between the comment delimiter (//) and the comment text, as shown in the following example.

```c#
// The following declaration creates a query. It does not run
// the query.
```

* Do not create formatted blocks of asterisks around comments.

## Naming
### Publics
Camel case
ex. thisPublicVariable

### Privates
Camel case
ex. thisPrivateVariable
	
### Statics
Camel case
ex. thisStaticVariable

### Constants
Upper case (e.g. `THISCONST`)

### Properties
Pascal Case (e.g. `ThisProperty`)

### Namespace(s)
Pascal Case (e.g. `Microsoft.Office` or `UVSim.AddressSpace`)

This recommendation is provided by [Microsoft - Names of Namespaces](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces).

### Class and Resource Files
Pascal Case (e.g. `ThisFile.cs`)

### Other
Standard case
ex. This text