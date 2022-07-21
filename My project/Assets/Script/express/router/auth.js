var express = require("express")
var router = express()

var Customer = require('../customer')


router.get('/', function (request, response) {
    response.send("authenticatiob")

})

router.post('/sign-in', function (request, response) {
    console.log(request.body) 

    var customer_ = new Customer({
        name: request.body.name,
        password: request.body.password

    })
    customer_.save((error) => {
        if (error) {
            throw error;
        }

            response.send("saved")
    })
})



router.post('/Login', function (request, response) {
    console.log(request.body)

    Customer.find({ name: request.body.name }, (error, data) => {
        if (error) {

            throw error
        }

        console.log("kullanıcı kayıtlı ")
        console.log(data[0])
        console.log(request.body.password)
        if (data[0].password == request.body.password) {
            response.send("giriş basarili")
        }
        else{
            response.send("sifre yanlış ")
        }






    })



})

router.put('/', function (request, response) {

})

router.delete('/', function (request, response) {

})

module.exports = router;