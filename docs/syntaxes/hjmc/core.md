# HJMC Syntax

all values are space seperated.  
statement are line seperated

## Macro
defining macro would change the parsing of value in compile time.

> [!NOTE]  
> String will also be affected

### Syntax
`#define [IDENTIFIER] [values]`
`#function [FUNCTION] [values]`

> [!NOTE]  
> `values` could be space seperated  

> [!IMPORTANT]  
> `IDENTIFIER` could not be a defined keyword eg. `function`  
> To replace keyword, see [Keyword Replacement](##keyword-replacement)

### Example

#### HJMC
```
#define CONSTANT 3
#define SPACED CONSTANT + CONSTANT
#function func(x) execute if x
```

#### JMC
```ts
constant = CONSTANT; // constant = 3;
spaced = SPACED; // constnt = CONSTANT + CONSTANT;
command: func(x);
```


## Command
defining a command would make a custom command recognizable  

### Syntax
`#command [command] <argument_parsers>`

#### Argument Parser
- Keyword: `keyword`  
- Parser: `parser:minecraft:vec3`

> [!IMPORTANT]  
> `arguments_parsers` only support vanilla argument only

### Example

#### HJMC

```
#command custom command parser:minecraft:vec3
#command custom command parser:minecraft:vec2
```

#### JMC
```ts
command: custom command ~ ~;
```

## Keyword Replacement
This is use for replacing defined keyword with user-defined one.  

> [!IMPORTANT]  
> you can not define a new keyword with this

### Syntax
`#keyword [DEFINED_KEYWORD] [REPLACE]`

### Example

#### HJMC
```
#keyword function def
```

#### JMC
```
def test() {}
```