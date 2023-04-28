import { DATA__PATH } from "./pathConfig.js"
import readFiles from "./readFiles.js"
import productTransferReport from "./productTransferReport.js"
import formatData from "./formatData.js"
import salesSituationReport from "./salesSituationReport.js"
import salesChannelReport from "./salesChannelReport.js"
import clearReports from "./clearReports.js"

clearReports()

readFiles(DATA__PATH)
  .then(formatData)
  .then(salesSituationReport)
  .then(salesChannelReport)
  .then(productTransferReport)
