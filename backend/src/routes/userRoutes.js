const express = require('express');
const router = express.Router();
const userController = require('../controllers/userController'); // Import your userController

// Define your user routes
router.get('/', (req, res) => {
  res.send('Hello World!')
})

router.get('/user', userController.getAllUsers);
router.put('/:userId', userController.updateProfile);




module.exports = router;
