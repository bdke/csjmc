# Vanilla Command

## Functions
command only function
```ts
command function commandFunc() {
    execute if @s;
    $var = 3; // this will throw error
}
```

combined function
```ts
function func()  {
    $var = 3;
    test = 4;
    execute if @s;// this will throw error
    command: execute if @s;
    command {
        execute if @s;
        data get @s;
        $var = 3; // this will throw error
    }
}
```