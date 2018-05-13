import {autoinject} from 'aurelia-framework';
import {Parent} from "aurelia-framework";
import {Router} from "aurelia-router";
import {HttpClient} from "aurelia-http-client";

@autoinject
export class JobDetailsView {
    schedulerName: string;
    group: string;
    name: string;
    details: any;

    constructor(private router: Router, private http: HttpClient) {
    }

    activate(params: any) {
        this.schedulerName = params.schedulerName;
        this.group = params.group;
        this.name = params.name;
        return this.loadDetails();
    }

    pause() {
        this.postCommand("pause");
    }

    resume() {
        this.postCommand("resume");
    }

    trigger() {
        this.postCommand("trigger");
    }

    delete() {
        bootbox.confirm({
            size: "small",
            message: `Delete ${this.name}?`,
            callback: (result: boolean) => {
                if (result) {
                    return this.http.delete(`/api/schedulers/${this.schedulerName}/jobs/${this.group}/${this.name}`).then(() => {
                        toastr.success(`Job ${this.group}.${this.name} deleted successfully`);
                        return this.router.navigate("jobs");
                    });
                }
                return $.when();
            }
        });
    }

    postCommand(command: string) {
        return this.http.post(`/schedulers/${this.schedulerName}/jobs/${this.group}/${this.name}/${command}`, null).then(() => {
            return this.loadDetails();
        });
    }

    loadDetails() {
        return this.http.get(`/api/schedulers/${this.schedulerName}/jobs/${this.group}/${this.name}/details`).then(response => {
            this.details = response.content;
        });
    }
}