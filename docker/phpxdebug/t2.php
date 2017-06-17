<?php
// php7.0

ini_set('xdebug.collect_vars', 'on');
ini_set('xdebug.collect_params', '4');
ini_set('xdebug.dump_globals', 'on');
ini_set('xdebug.dump.SERVER', 'REQUEST_URI');
ini_set('xdebug.show_local_vars', 'on');
ini_set('xdebug.profiler_enable', 'on');
// document.cookie = "XDEBUG_PROFILE=1";
// document.cookie = "XDEBUG_SESSION=XDEBUG_ECLIPSE";

// export XDEBUG_CONFIG="idekey=session_name remote_host=localhost profiler_enable=1"
// XDEBUG_SESSION XDEBUG_ECLIPSE
// https://xdebug.org/docs/basic
$a = 'Test1 ';
$b = 'Test b';

echo $a . "\n ";

// # echo  xdebug_call_class();
// # echo  "::". xdebug_call_function();
//  updateProperties.code = 'if(document.cookie.indexOf("XDEBUG_PROFILE") > -1) 
// document.cookie = "XDEBUG_PROFILE=; expires=Thu, 01 Jan 1970 00:00:00 UTC"; else 
     
echo "\naTrace: ";
$aTrace = debug_backtrace();
var_dump( $aTrace);

echo "\nnetstat -atn | findstr 900\n";

if (extension_loaded('xdebug')) {
   
   xdebug_start_code_coverage();

   echo  "\n\niscalled at " , xdebug_call_file();
   echo  "\ndump code_coverage: ";
   var_dump(xdebug_get_code_coverage());

   echo  "\nbreak: ";
   // xdebug_break();
}
else 
   echo  "\nno ext xdebug";
    
echo "\nxdebug_get_declared_vars: ";
var_dump(xdebug_get_declared_vars());

var_dump($b);
 
xdebug_time_index();

echo "\nline: ";
echo xdebug_call_line();
xdebug_stop_code_coverage();

?>

