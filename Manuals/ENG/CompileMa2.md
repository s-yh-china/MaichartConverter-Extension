# Manual for `ComposeMa2` command

### Compile assigned Ma2 chart to assigned format

## Basic usage

    MaichartConverter ComposeMa2 --params

## Example usage

    MaichartConverter ComposeMa2 -p "/Users/Neskol/MaiAnalysis/A000/music/music000363/000363_03.ma2" -f Ma2_104

## Available Parameters

### Required Params:

> Unless otherwise specified, `XXXXXX` here stands for musicID.

- `-p | --path <path>`: Path to .ma2 file to be converted.

### Optional Params:

> Program will print result in the terminal if `-o | --output` parameter is not provided.

- `-f | --format <string>`: Forces program to compile carts in given format. Available
  format: `Simai, SimaiFes, Ma2, Ma2_104`. Note: Festival features requires `SimaiFes` or `Ma2_104` parameter.
- `-r | --rotate <string>`: Forces program to rotate all charts in given method. Available
  rotations: `Clockwise90, Clockwise180, CounterClockwise90, CounterClockwise180, UpsideDown, LeftToRight`.
- `-s | --shift <int>`: Shifts notes in all charts front or back by given ticks.
- `-o | --output <path>`: Path to output folder. Program will try to write to this path and create new folder when
  necessary so make sure you have write permission of the given folder.

## Mine / SV / HS extensions

This command can read and preserve custom records used by `SinmaiMineNote`:

- Mine aliases such as `MINE_NMTAP`, `MINE_NMHLD`, `MINE_NMSTR`, `MINE_NMTTP`, `MINE_NMTHO`, `MN*`, and `MI*`.
- SV records in change-point form `SV	<bar>	<grid>	<speed>` and explicit segment form
  `SV	<bar>	<grid>	<endBar>	<endGrid>	<speed>`. `SVEL`, `SVELC`, and `SOFLAN` are accepted as input aliases.
- HS records in change-point form `HS	<bar>	<grid>	<speed>`. `HSP`, `HSPD`, `HSPEED`, and `HISPEED` are accepted as
  input aliases.
- Per-note inline HS before note tags, such as `<HS*2>NMTAP	0	0	0` and `<HS*0.75>MINE_NMTAP	0	96	1`.
  `MINE_<HS*speed>...` is accepted for compatibility and normalized on output.

When compiling back to `Ma2_104`, Mine records are normalized to `MINE_<nativeTag>`, SV records are normalized to
`SV`, HS records are normalized to `HS`, and inline HS is written before the note tag. When compiling to Simai, Mine
notes are written with the `m` marker, SV changes as `(SV:<speed>)`, HS changes as `(HS:<speed>)`, and per-note HS as
`<HS*speed>`.
