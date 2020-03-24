Description="Adds special character to wrappedd line endings"

Categories = {"format", "usability" }

function syntaxUpdate(desc)  

  if (HL_OUTPUT == HL_FORMAT_HTML or HL_OUTPUT == HL_FORMAT_XHTML) then
    lineWrappedChar = ' &#x21a9;'
  elseif (HL_OUTPUT == HL_FORMAT_LATEX) then
    lineWrappedChar = ''    -- nothing, because in LaTeX the line wrap arrow is outputted by highlight itself
  else
    lineWrappedChar = ' \u{21a9}'
  end

  function init()
    currentLineNumber = 0 -- remember the current line number
  end
    
  init()  
  
  function DecorateLineBegin(lineNumber)
    if lineNumber == 1 then
      init()
    end 

    -- the line number does not increase for wrapped lines (--wrap, --wrap-simple)
    if (tonumber(currentLineNumber) == lineNumber) then
      return
    end

    currentLineNumber = string.format("%d", lineNumber)
    return
  end

  function DecorateLineEnd(lineNumber)  
    print("linenumber = ", lineNumber, ", currentLineNumber = ", currentLineNumber)
    if (tonumber(currentLineNumber) == lineNumber) then
      print("line decorated")
      return lineWrappedChar
    end
    return
  end

end

Plugins={
  { Type="lang", Chunk=syntaxUpdate }
}
