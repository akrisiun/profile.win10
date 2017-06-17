<?php
// php7.0

// https://xdebug.org/docs/basic
class Strings 
{ 
     static function fix_string($a)
     {
        echo
             xdebug_call_class().
                            "::".
             xdebug_call_function().
                "  is called at ".
             xdebug_call_file().
              ":".
             xdebug_call_line();
    }
}

$ret = Strings::fix_string('Derick');

?>

