import {TestModule} from "app"
//alert( test.TestModule.testFunc( "sdasd" ) );
alert(TestModule.testFunc("asfasf"));
var instance = new TestModule.TestClass;
alert( instance.name );