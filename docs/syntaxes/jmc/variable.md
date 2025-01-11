# Variable Syntax

## Scoreboard

Generic cases

```
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

### Disposable Variable

`using` keyword could make a scoreboard be removed at the end of the function.

```ts
using $var = 3;
```

### Concat Variable Name

anythings in `${}` will joined to form a scoreboard.

```
// this will compile as $nametest
${name, test} = 3;
```

> [!NOTE]  
> if test is assigned as 3, it will compile as `$name3` instead

### Array Variable

```
//array
$var = ["test", 3];
```

## Constants

You can put this in anywhere.

> ![NOTE]  
> `constants` will be compiled and can not access through `scoreboard` or `data` command

> ![WARNING]  
> using values of `variable` is not allowed in `constants`  
> e.g. `test = $"{$var} test"`  this will throw error

```
test = "3";
test -= 3;

//string intorparation
test = $"{test} test";

//color string
test = &"<red>amogus</>";

//combined
test = $&"<red>{test}</>";

//array
test = ["test", 1];
```
