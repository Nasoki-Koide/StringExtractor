# StringExtractor
You can extract a part of string from long string.
```
using StringExtractors;

var longString = "It takes three hours.";
// result is "three".
var result = StringExtractor.Extract(longString, "takes ", " hours.").Value;
```

If you want to extract a string which is located at head or end of long string, omit leftString or rightString.
```
using StringExtractors;

var longString = "One Two Three";
// leftString is omitted. result1 is "One".
var result1 = StringExtractor.Extract(longString, rightString: " Two").Value;

// rightString is omitted. result2 is "Three".
var result2 = StringExtractor.Extract(longString, leftString: "Two ").Value;
```

For more complicated case, use StringExtractorParameters.
```
using StringExtractors;

var longString = "I'm Jack. I'm Tyler."

// Search leftString from the end of longString. So, result is "Tyler".
var leftString = new LeftString(
    "I'm ",
    direction: SearchDirection.Backward);

var rightString = new RightString(".");

var parameters = new StringExtractorParameters(
    longString,
    leftString,
    rightString
);

// "Tyler"
var result = StringExtractor.Extract(parameters).Value;
```

```
using StringExtractors;

var longString = "I'm George Washington. I'm Abraham Lincoln."

var leftString = new LeftString("I'm ");

var rightString = new RightString("Lincoln.");

// Search rightString first. So, result is "Abraham".
var parameters = new StringExtractorParameters(
    longString,
    leftString,
    rightString,
    searchOrder: SearchOrder.RightFirst
);

// "Abraham"
var result = StringExtractor.Extract(parameters).Value;
```

Extract method of StringExtractor returns ExtractionResult.
ExtractionResult has two properties, Value and IndexCollection.
Value is extracted string. 
IndexCollection has three properties,
Left (index of LeftString in source. Source is longString in above examples), 
Right (index of RightString in source.), 
Head (index of extracted string in source.).

StringExtractorParameters has five arguments.
Source is a string which contains extract target.
LeftString is a string locates at left side of extract target. Omit this if extract target
locates at head of source.
RightString is a string locates at right side of extract target. Omit this if extract target
locates at end of source.
SearchOrder specifies which of LeftString or RightString is searched first.
StartIndex is an index of start searching.

