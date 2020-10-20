# README

## Syntax

### Arguments

Address:
    prefix:
    Description:
    number used like a pointer to a memory addr

Address of var:
    prefix: &
    Description:
    Gets the address the var is pointing to

Value at Address of var:
    prefix: $
    Description:
    Gets the value that's stored in the address the var is pointing to

Value at Memory address:
    prefix: #
    Description:
    Gets the value that's stored in the memory address

#### Explanation

```yml
vars:
    - name: "num1"
      value: 0
    - name: "num2"
      value: 2
    - name: "res"
      value: 1


memory:
    - [0, 0, 1, 0]
    - [0, 0, 0, 1]
    - [0, 1, 1, 0]
    - [1, 0, 1, 1]
```

&num1 = 0
&num2 = 2
&res = 1

$num1 = [0, 0, 1, 0] = 2
$num2 = [0, 1, 1, 0] = 6
$res = [0, 0, 0, 1] = 1

\#3 = memory[3] = [1, 0, 1, 1] = 11
\#1 = memory[1] = [0, 0, 1, 0] = 1

[instruction] [dest],[src]

### Instructions

MOV [value|&addr|$addr],[value|&var|$var|#memory_index]

-----------

JMPN [&addr|$addr|#memory_index],[section]    ; value can be used as dest but shouldn't

JMPN, Jump if value is 0

-----------

JMPJ [&addr|$addr|#memory_index],[section]    ; value can be used as dest but shouldn't

JMPJ, Jump if value is 1

### TODO

src should be able to be a memory location, # perhaps, #1 for mem index 1
