package part2

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

const (
	meLose      = "X"
	meDraw      = "Y"
	meWin       = "Z"
	elfRock     = "A"
	elfPaper    = "B"
	elfScissors = "C"
)

const (
	rock     = 1
	paper    = 2
	scissors = 3
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
		totalScore += roundScore(r[1]) + shapeScore(r[0], r[1])
	}

	fmt.Println(totalScore)
}

func roundScore(me string) int {
	switch me {
	case meLose:
		return lose
	case meDraw:
		return draw
	case meWin:
		return win
	}

	return 0
}

func shapeScore(elf, me string) int {
	if me == meLose {
		switch elf {
		case elfRock:
			return scissors
		case elfPaper:
			return rock
		case elfScissors:
			return paper
		}
	}
	if me == meDraw {
		switch elf {
		case elfRock:
			return rock
		case elfPaper:
			return paper
		case elfScissors:
			return scissors
		}
	}
	switch elf {
	case elfRock:
		return paper
	case elfPaper:
		return scissors
	case elfScissors:
		return rock
	}
	return 0
}
