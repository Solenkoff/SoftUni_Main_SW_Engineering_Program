import { Router } from 'express';

import recipeService from '../services/disasterService.js';
import { isAuth } from '../middlewares/authMiddleware.js';
import { getErrorMessage } from '../utils/errorUtil.js';

const recipeController = Router();



export default recipeController;   