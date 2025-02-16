export interface CommandRegion {
    start: ServerPositionType,
    end: ServerPositionType
}

export interface ServerPositionType {
    line: number,
    column: number
}