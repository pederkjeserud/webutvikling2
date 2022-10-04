import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
        name: "Home",
        path: "/",
        alias: "/hjem",
        component: () => import('../views/Home.vue')
    },
    {
        name: "Artist",
        path: "/artister",
        alias: "/book",
        component: () => import('../views/Artist.vue')
    },
    {
        name: "Jobs",
        path: "/oppdrag",
        component: () => import('../views/Jobs.vue')

    },
    {
        name: "ArtistAdmin",
        path: "/artist-admin",
        component: () => import('../views/ArtistAdmin.vue')
    },
    {
        name: "JobsAdmin",
        path: "/oppdrag-admin",
        component: () => import('../views/JobsAdmin.vue')
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;