import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: () => import("../views/HomeView.vue"),
    },
    {
      path: "/entity/add",
      name: "entity-add",
      component: () => import("../views/entity/AddRecord.vue"),
    },
    {
      path: "/entity/delete",
      name: "entity-delete",
      component: () => import("../views/entity/DeleteRecord.vue"),
    },
    {
      path: "/entity/list",
      name: "entity-list",
      component: () => import("../views/entity/ListRecords.vue"),
    },
    {
      path: "/entity/search",
      name: "entity-search",
      component: () => import("../views/entity/SearchRecords.vue"),
    },
    {
      path: "/webservice/add",
      name: "webservice-add",
      component: () => import("../views/webservice/AddRecord.vue"),
    },
    {
      path: "/webservice/delete",
      name: "webservice-delete",
      component: () => import("../views/webservice/DeleteRecord.vue"),
    },
    {
      path: "/webservice/list",
      name: "webservice-list",
      component: () => import("../views/webservice/ListRecords.vue"),
    },
    {
      path: "/webservice/search",
      name: "webservice-search",
      component: () => import("../views/webservice/SearchRecords.vue"),
    },
  ],
});

export default router;
