package part1

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

const (
	meRock      = "X"
	mePaper     = "Y"
	meScissors  = "Z"
	elfRock     = "A"
	elfPaper    = "B"
	elfScissors = "C"
)

const (
	win  = 6
	draw = 3
	lose = 0
)

func Solve() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)
	rounds := [][]string{}
	for scanner.Scan() {
		rounds = append(rounds, strings.Fields(scanner.Text()))
	}

	if err := scanner.Err(); err != nil {
		log.Fatal(err)
	}

	totalScore := 0
	for _, r := range rounds {
		totalScore += roundScore(r[0], r[1]) + shapeScore(r[1])
	}

	fmt.Println(totalScore)
}

func roundScore(elf, me string) int {
	if me == meRock {
		switch elf {
		case elfRock:
			return draw
		case elfPaper:
			return lose
		case elfScissors:
			return win
		}
	}
	if me == mePaper {
		switch elf {
		case elfRock:
			return win
		case elfPaper:
			return draw
		case elfScissors:
			return lose
		}
	}
	switch elf {
	case elfRock:
		return lose
	case elfPaper:
		return win
	case elfScissors:
		return draw
	}

	return 0
}

func shapeScore(me string) int {
	switch me {
	case "X":
		return 1
	case "Y":
		return 2
	case "Z":
		return 3
	}
	return 0
}
