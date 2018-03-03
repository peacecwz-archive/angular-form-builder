(function() {
  angular
    .module("app", ["builder", "builder.components", "validator.rules"])
    .run()
    .controller("DemoController", [
      "$scope",
      "$builder",
      "$validator",
      function($scope, $builder, $validator) {
        $scope.form = $builder.forms["default"];
        $scope.input = [];
        $scope.defaultValue = {};

        $scope.createForm = function() {
          if ($scope.form.length === 0) {
            alert("You have not any component in your form");
          } else {
            alert(JSON.stringify($scope.form));
          }
        };

        $scope.addComponent = function(type) {
          switch (type) {
            case "input":
              $builder.addFormObject("default", {
                component: "textInput",
                editable: true,
                id: "textInput",
                label: "Text Input",
                description: "description",
                placeholder: "placeholder",
                options: [],
                required: false,
                validation: "/.*/"
              });
              break;
            case "textarea":
              $builder.addFormObject("default", {
                id: "textarea",
                component: "textArea",
                label: "Name",
                description: "Your name",
                placeholder: "Your name",
                required: true,
                editable: false
              });
              break;
            case "checkbox":
              $builder.addFormObject("default", {
                id: "checkbox",
                component: "checkbox",
                label: "Pets",
                description: "Do you have any pets?",
                options: ["Dog", "Cat"]
              });
              break;
            case "radio":
              $builder.addFormObject("default", {
                id: "radio",
                component: "radio",
                label: "Pets",
                description: "Do you have any pets?",
                options: ["Dog", "Cat"]
              });
              break;
            case "select":
              $builder.addFormObject("default", {
                id: "select",
                component: "select",
                label: "Pets",
                description: "Do you have any pets?",
                options: ["Dog", "Cat"]
              });
              break;
            default:
              $builder.addFormObject("default", {
                id: "textbox",
                component: "textInput",
                label: "Name",
                description: "Your name",
                placeholder: "Your name",
                required: true,
                editable: false
              });
              break;
          }
        };

        return ($scope.submit = function() {
          return $validator
            .validate($scope, "default")
            .success(function() {
              return console.log("success");
            })
            .error(function() {
              return console.log("error");
            });
        });
      }
    ]);
}.call(this));
