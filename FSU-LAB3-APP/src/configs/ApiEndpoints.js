
const apiBaseURL = 'https://localhost:7157/api';

const apiEndpoints = {
  login: `${apiBaseURL}/Auth/login`,
  register: `${apiBaseURL}/Auth/register`,
  products: `${apiBaseURL}/Products`,
  orders: `${apiBaseURL}/Orders`,
};

export default apiEndpoints;
