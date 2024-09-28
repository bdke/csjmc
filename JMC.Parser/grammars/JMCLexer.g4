lexer grammar JMCLexer;

SIMPLE_ADDICTIVE: '++' | '--' ;

MULTIPACATION: '*' | '/' | '%';
ADDICTIVE: '+' | '-';
COMPARATOR: '>' | '<' ;
COMPARASION: '==' | '!=' | '>=' | '<=';
ASSIGN: '=';
ASSIGN_OPERATORS: '%=' |'+=' | '-=' | '*=' | '/=' | '><' | '??=';
ARROW: '=>';
BLOCK_START: '{';
BLOCK_END: '}';
LIST_START: '[';
LIST_END: ']';
PAREN_START: '(' ;
PAREN_END: ')' ;
COLON: ':';
IMPLY: '::';

SELECTOR: '@'[parse] ;
RUN: 'run';

IMPORT: 'import';
FUNCTION: 'function';
WHILE: 'while';
IF: 'if';
ELSE: 'else';
END: ';' ;
SEP: ',';
NOT: '!';
COMMENT: ('//' | '#') ~[\r\n]* [\r\n]+;

COMMANDS: 
('advancement' | 'attribute' | 'ban' | 'ban-ip' | 'banlist' | 'bossbar' | 'clear' | 'clone' | 'damage' | 'data' | 'datapack' | 'debug' | 'defaultgamemode' | 'deop' | 
'difficulty' | 'effect' | 'enchant' | 'execute' | 'experience' | 'fill' | 'fillbiome' | 'forceload' | 'gamemode' | 'gamerule' | 'give' | 'help' | 
'item' | 'jfr' | 'kick' | 'kill' | 'list' | 'locate' | 'loot' | 'me' | 'msg' | 'op' | 'pardon' | 'pardon-ip' | 'particle' | 'perf' | 'place' | 'playsound' | 'publish' | 
'random' | 'recipe' | 'reload' | 'return' | 'ride' | 'save-all' | 'save-off' | 'save-on' | 'say' | 'schedule' | 'scoreboard' | 'seed' | 'setblock' | 'setidletimeout' | 
'setworldspawn' | 'spawnpoint' | 'spectate' | 'spreadplayers' | 'stop' | 'stopsound' | 'summon' | 'tag' | 'team' | 'teammsg' | 'teleport' | 'tell' | 'tellraw' | 'tick' | 
'time' | 'title' | 'tm' | 'tp' | 'trigger' | 'w' | 'weather' | 'whitelist' | 'worldborder' | 'xp');

INTEGER: [1-9][0-9]*;
INT_VALUE: [0-9]+ 'b' ;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: ('"' ~[\r\n"]* '"') | ('\'' ~[\r\n']* '\'');
BOOL: 'true' | 'false';
NULL: 'null';

fragment ESC
    : '\\' (["\\/bfnrt] | UNICODE)
    ;

fragment UNICODE
    : 'u' HEX HEX HEX HEX
    ;

fragment HEX
    : [0-9a-fA-F]
    ;

fragment SAFECODEPOINT
    : ~ ["\\\u0000-\u001F]
    ;

NUMBER
    : '-'? INT ('.' [0-9]+)? EXP?
    ;

fragment INT
    // integer part forbis leading 0s (e.g. `01`)
    : '0'
    | [1-9] [0-9]*
    ;

// no leading zeros

fragment EXP
    // exponent number permits leading 0s (e.g. `1e01`)
    : [Ee] [+-]? [0-9]+
    ;

WS: [ \t\r\n]+ -> skip;
VARIABLE_IDENTIFIER: '$' [a-zA-Z_.][a-zA-Z0-9_.]* ;
IDENTIFIER: [a-zA-Z_.][a-zA-Z0-9_.]*;