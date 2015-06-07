var fs = require( "fs-extra" );
var project = fs.readJSONSync( "./project.json" );

var GulpConfig = ( function() {
    function gulpConfig() {
        this.www = project.webroot;
        this.contentRoot = this.www + "/content";
        this.cssRoot = this.contentRoot + "/css";
        this.jsRoot = this.www + "/js";
        this.jsLib = this.jsRoot + "/lib";
        this.jsApp = this.jsRoot + "/app";
        this.bower = "./bower_components/";
        this.tsSource = "./App";
        this.lessSource = "./Content/Less";

        this.allTs = this.tsSource + "/**/*.ts";
        this.allLess = this.lessSource + "/**/*.less";

        this.tsTypings = "./Tools/Typings";
        this.libTypeDefs = this.tsTypings + "/**/*.ts";
        this.appTypeDef = this.tsTypings + "/app.d.ts";
    }

    return gulpConfig;
} )();
module.exports = GulpConfig;