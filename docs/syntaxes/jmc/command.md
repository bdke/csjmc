# Vanilla Command

## Namespace

```ts
function foo.bar(i) {
    i = 3;
}

class test {
    function a(i) {
        $var = i;
        foo.bar(3);
    }

    command {
        execute 
            if @s;
    }
}

test.a(3);
//$var will be 3
print($var);
```