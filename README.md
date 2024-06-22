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

// Searching leftString from the end of longString. So, result is "Tyler".
var leftString = new LeftString(
    "I'm ",
    direction: SearchDirection.Backward);

var rightString = new RightString(".");

var parameters = new StringExtractorParameters(
    longString,
    leftString,
    rightString
);

var result = StringExtractor.Extract(parameters).Value;
```