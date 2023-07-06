package main

import "strconv"

func IsEven(input int) bool {
	return input%2 == 0
}

func Fooer(input int) string {
	isfoo := (input % 3) == 0

	if isfoo {
		return "Foo"
	}

	return strconv.Itoa(input)
}
