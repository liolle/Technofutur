import { Route } from "@types";
import {handle404} from "@/pages/404"

export class Router{

  private route :Route|null = null
  private routes:Route[] = [
    {
      path:"/404",
      handler:handle404
    }
  ]
  constructor() {
    if(!window){
      throw new Error("Missing Window context");
    }

    window.addEventListener("",this.handleRouteChange)
  }

  /**
   * Registers a new route with a path and a handler function.
   * @param path - The path of the route (e.g., "/about")
   * @param handler - A function to run when the path is active
   */
  addRoute(path: string, handler: () => void) {
    this.routes.push({ path, handler });
  }

  /**
   * Navigates to the specified path, updating the URL and calling the handler.
   * @param path - The path to navigate to
   */
  navigate(path: string) {
    if(this.route){
      this.route.handler.cleanUp()
    }
    window.history.pushState({}, "", path);
    this.handleRouteChange();
  }


  /**
   * Finds and runs the handler for the current path.
   */
  private handleRouteChange() {
    const path = window.location.pathname;
    const route = this.routes.find(route => route.path === path);
    this.route = route
    
    if (route) {
      route.handler.handle();
    } else {
      this.navigate("/404")
    }
  }
}

