in_filename=$1
out_filename="$1.html"
if [ -n "$2" ]; then
	line_range="--line-range $2 $3"
else
	line_range=""
fi

highlight --style edit-msvs2008 --wrap --line-length=60 --out-format html --plug-in line_wrap.lua --validate-input $line_range --input $in_filename --output $out_filename
# pageres $out_filename 800x600 --scale 10 --filename="$out_filename"
# convert "$out_filename.png" -trim -bordercolor white -border 100 "$out_filename-trimmed.png"
