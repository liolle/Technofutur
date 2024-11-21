import  "@/style.css"
import { Router } from "@/router";
import { rootHandle } from "./pages/root";
import { editHandle } from "./pages/edit";

const router = new Router()
router.addRoute("/",rootHandle)
router.addRoute("/edit",editHandle)
router.handleRouteChange()
