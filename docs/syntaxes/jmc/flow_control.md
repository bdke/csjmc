# Flow Control

```

if ($var == 3) {
    $var = 4;
}
else if ($var == 4) {
    $var = 5;
}
else {
    $var = 10;
}
do {
    $var = 3;
} while (true)
while (true) {
    $var = 3;
}
switch ($var) {
    case 1:
        $var = 2;
    case 2:
        $var = 4;
    default:
        $var = 0;
}

for ($var = 0; $var < 4; $var++) {
    print($var);
}

array = [1,2,3];
for (item in array) {
    ${var, item} = item;
}

```