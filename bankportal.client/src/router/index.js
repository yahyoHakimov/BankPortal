import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    { path: '/', component: Dashboard }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router   