# Variable Syntax

## Scoreboard
Generic cases
```ts
$var = 3 + (3);
$var++;
$var -= 1;
$var = name;
$var = 3 + num;
$var >< 3;

//null collesacle
$var ??= 3;

//store
$var ?= execute if @s;
```

`using` keyword could make a scoreboard be removed at the end of the function.
```ts
using $var = 3;
```

anythings in `${}` will joined to form a scoreboard.
```ts
// this will compile as $nametest
${name, test} = 3;
```
> [!NOTE]  
> if test is assigned as 3, it will compile as `$name3` instead

## Static

```ts
test = "3";
test -= 3;

//string intorparation
test = $"{test} test";

//color string
test = &"<red>amogus</>";

//combined
test = $&"<red>{test}</>"

//array
test = ["test", 1]
```