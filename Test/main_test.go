package main

import "testing"

func TestIsEven(t *testing.T) {
	result := IsEven(2)
	if !result {
		t.Errorf("Result was incorrect, got: %d, want: %d", 1, 0)
	}
}

func TestFooer(t *testing.T) {
	result := Fooer(3)
	if result != "Foo" {
		t.Errorf("Result was incorrect, got: %s, want: %s", result, "Foo")
	}
}
