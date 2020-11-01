# Conversion

## NumberTo

### RomanNumeral

``` csharp

using BBUnity.Converstion;

NumberTo.RomanNumeral(1); //I
NumberTo.RomanNumeral(5); //V
NumberTo.RomanNumeral(10); //X
NumberTo.RomanNumeral(100); //C
NumberTo.RomanNumeral(1000); //M

```

### RetroScore

``` csharp

using BBUnity.Converstion;

NumberTo.RetroScore(1); //0000000001
NumberTo.RetroScore(100); //0000000100
NumberTo.RetroScore(100000); //0000100000
NumberTo.RetroScore(10000000); //0010000000
NumberTo.RetroScore(1000000000); //1000000000

```

## ListTo

### String

``` csharp

using BBUnity.Conversion;

ListTo.String(new List<string> {"hello", "world"}); //hello-world
ListTo.String(new List<string> {"hello", "world"}, "**"); //hello**world

```
