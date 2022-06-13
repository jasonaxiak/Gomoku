# Gomoku API

## Notes

- Swagger UI interface has been provided for the API
- The following API call will create a board and return an id for that board - GET api/board
- The following API call places a stone on the board PUT api/board/<board id>

## Assumptions

- Board size of 15 x 15
- Winning chain length of 5 consecutive pieces/stones, vertically, horizontally or diagonally
- Piece are place on the board using a 0 index (i.e. Row 0, Column 0 is the first position)
