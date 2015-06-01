/// <reference path="../../Tools/Typings/tsd.d.ts" />
module Dota2App.Controllers {
    export class TestController {
        name: string;

        static $inject = [
            "$scope"
        ];

        constructor( $scope: ng.IScope ) {
            this.name = "sdsd";
        }
    }
}